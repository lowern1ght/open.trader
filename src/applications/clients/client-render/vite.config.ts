import react from '@vitejs/plugin-react-swc'
import {defineConfig, loadEnv, ProxyOptions} from 'vite'

interface ITraderClientConfig {
  port?: number,
  proxy?: Record<string, string | ProxyOptions>
}

export default ({ mode }) => {
  process.env = {...process.env, ...loadEnv(mode, process.cwd())};

  let target : string = process.env?.TRADER_PROXY_URL ?? "https://localhost:2000";
  
  const defaultProxy = {
    '/api': {
      changeOrigin: true,
      target: target,
      rewrite: (path) => path.replace(/^\/api/, ''),
    }
  }
  
  const defaultConfig : ITraderClientConfig = {
    port: parseInt(process.env?.TRADER_CLIENT_PORT ?? `4000`),
    proxy: defaultProxy
  }

  let traderClientConfig =  defaultConfig;

  if (traderClientConfig.proxy == null) {
    traderClientConfig.proxy = defaultProxy
  }
  
  return defineConfig({
    plugins: [react()],
    server: {
      strictPort: true,
      port: traderClientConfig.port,
      proxy: traderClientConfig.proxy,
      host: "0.0.0.0"
    },
    preview: {
      port: traderClientConfig.port,
      proxy: traderClientConfig.proxy,
      host: "0.0.0.0"
    }
  })
}