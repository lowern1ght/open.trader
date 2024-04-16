/// <reference types="vite/client" />

interface ImportMetaEnv {
    readonly TRADER_PORT: string
    readonly TRADER_PROXY_HOST: string
    readonly TRADER_PROXY_API_PART: string
    readonly TRADER_USE_MOCK_AXIOS: string
    readonly TRADER_REACT_APP_VERSION: string
}

interface ImportMeta {
    readonly env: ImportMetaEnv
}