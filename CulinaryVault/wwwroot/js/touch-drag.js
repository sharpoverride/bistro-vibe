window.touchDrag = {
    draggedElement: null,
    draggedIndex: null,
    placeholder: null,
    container: null,
    dotNetRef: null,
    itemType: null,
    initialY: 0,
    currentY: 0,
    offsetY: 0,
    isDragging: false,

    initialize: function (dotNetRef) {
        this.dotNetRef = dotNetRef;
        this.setupTouchListeners();
    },

    dispose: function () {
        this.dotNetRef = null;
        this.cleanup();
    },

    setupTouchListeners: function () {
        // Use event delegation on document for touch events
        document.addEventListener('touchstart', this.handleTouchStart.bind(this), { passive: false });
        document.addEventListener('touchmove', this.handleTouchMove.bind(this), { passive: false });
        document.addEventListener('touchend', this.handleTouchEnd.bind(this), { passive: false });
        document.addEventListener('touchcancel', this.handleTouchEnd.bind(this), { passive: false });
    },

    handleTouchStart: function (e) {
        const handle = e.target.closest('[data-drag-handle]');
        if (!handle) return;

        const row = handle.closest('[data-drag-item]');
        if (!row) return;

        e.preventDefault();

        const touch = e.touches[0];
        this.draggedElement = row;
        this.draggedIndex = parseInt(row.dataset.dragIndex, 10);
        this.itemType = row.dataset.dragItem;
        this.container = row.parentElement;
        this.initialY = touch.clientY;
        this.isDragging = false;

        // Get the offset from the top of the element
        const rect = row.getBoundingClientRect();
        this.offsetY = touch.clientY - rect.top;
    },

    handleTouchMove: function (e) {
        if (!this.draggedElement) return;

        e.preventDefault();

        const touch = e.touches[0];
        this.currentY = touch.clientY;

        // Start dragging after a small movement threshold
        if (!this.isDragging && Math.abs(this.currentY - this.initialY) > 5) {
            this.startDrag();
        }

        if (this.isDragging) {
            this.updateDragPosition(touch);
            this.checkDropTarget(touch);
        }
    },

    startDrag: function () {
        this.isDragging = true;

        // Create placeholder
        this.placeholder = document.createElement('div');
        this.placeholder.className = 'drag-placeholder';
        this.placeholder.style.height = this.draggedElement.offsetHeight + 'px';
        this.placeholder.style.background = '#e2e8f0';
        this.placeholder.style.borderRadius = '0.75rem';
        this.placeholder.style.border = '2px dashed #94a3b8';
        this.placeholder.style.marginBottom = '0.5rem';

        // Insert placeholder
        this.draggedElement.parentNode.insertBefore(this.placeholder, this.draggedElement);

        // Style the dragged element
        const rect = this.draggedElement.getBoundingClientRect();
        this.draggedElement.style.position = 'fixed';
        this.draggedElement.style.zIndex = '1000';
        this.draggedElement.style.width = rect.width + 'px';
        this.draggedElement.style.left = rect.left + 'px';
        this.draggedElement.style.top = rect.top + 'px';
        this.draggedElement.style.opacity = '0.9';
        this.draggedElement.style.boxShadow = '0 10px 25px rgba(0,0,0,0.15)';
        this.draggedElement.style.transform = 'scale(1.02)';
        this.draggedElement.style.pointerEvents = 'none';
        this.draggedElement.classList.add('dragging');
    },

    updateDragPosition: function (touch) {
        const newTop = touch.clientY - this.offsetY;
        this.draggedElement.style.top = newTop + 'px';
    },

    checkDropTarget: function (touch) {
        const items = Array.from(this.container.querySelectorAll('[data-drag-item="' + this.itemType + '"]:not(.dragging)'));

        for (let i = 0; i < items.length; i++) {
            const item = items[i];
            const rect = item.getBoundingClientRect();
            const midY = rect.top + rect.height / 2;

            if (touch.clientY < midY) {
                if (item !== this.placeholder.nextElementSibling) {
                    this.container.insertBefore(this.placeholder, item);
                }
                return;
            }
        }

        // If we're past all items, append placeholder at end
        const lastItem = items[items.length - 1];
        if (lastItem && this.placeholder.nextElementSibling !== null) {
            this.container.appendChild(this.placeholder);
        }
    },

    handleTouchEnd: function (e) {
        if (!this.draggedElement) return;

        if (this.isDragging) {
            // Calculate drop index based on placeholder position
            const items = Array.from(this.container.querySelectorAll('[data-drag-item="' + this.itemType + '"]:not(.dragging)'));
            let dropIndex = items.indexOf(this.placeholder.nextElementSibling);
            if (dropIndex === -1) {
                dropIndex = items.length;
            }

            // Clean up visual styles
            this.draggedElement.style.position = '';
            this.draggedElement.style.zIndex = '';
            this.draggedElement.style.width = '';
            this.draggedElement.style.left = '';
            this.draggedElement.style.top = '';
            this.draggedElement.style.opacity = '';
            this.draggedElement.style.boxShadow = '';
            this.draggedElement.style.transform = '';
            this.draggedElement.style.pointerEvents = '';
            this.draggedElement.classList.remove('dragging');

            // Remove placeholder
            if (this.placeholder && this.placeholder.parentNode) {
                this.placeholder.parentNode.removeChild(this.placeholder);
            }

            // Notify Blazor of the drop
            if (this.dotNetRef && this.draggedIndex !== dropIndex) {
                this.dotNetRef.invokeMethodAsync('HandleTouchDrop', this.itemType, this.draggedIndex, dropIndex);
            }
        }

        this.cleanup();
    },

    cleanup: function () {
        this.draggedElement = null;
        this.draggedIndex = null;
        this.placeholder = null;
        this.container = null;
        this.itemType = null;
        this.isDragging = false;
    }
};
