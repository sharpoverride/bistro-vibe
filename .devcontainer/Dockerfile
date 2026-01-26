# Dev container for Bistro Vibe / Cămara Culinară
FROM mcr.microsoft.com/devcontainers/dotnet:1-10.0

# Install Playwright dependencies for E2E testing
RUN apt-get update && apt-get install -y \
    libnss3 \
    libnspr4 \
    libatk1.0-0 \
    libatk-bridge2.0-0 \
    libcups2 \
    libdrm2 \
    libdbus-1-3 \
    libxkbcommon0 \
    libatspi2.0-0 \
    libxcomposite1 \
    libxdamage1 \
    libxfixes3 \
    libxrandr2 \
    libgbm1 \
    libasound2 \
    && rm -rf /var/lib/apt/lists/*

# Create data directory for SQLite database (separate from docker-compose volume)
RUN mkdir -p /workspace/data && chown vscode:vscode /workspace/data

WORKDIR /workspace
