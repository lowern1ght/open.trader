import react from '@vitejs/plugin-react-swc'
import {defineConfig, loadEnv, ProxyOptions} from 'vite'

const defaultProxy = {
  "/web-api": {
    changeOrigin: true,
    target: `http://localhost:8001`,
    rewrite: (path) => path.replace(/^\/web-api/, ''),
  }
}

interface ITraderClientConfig {
  port?: number,
  proxy?: Record<string, string | ProxyOptions>
}

export default ({ mode }) => {

  const defaultConfig : ITraderClientConfig = {
    port: 12000,
    proxy: defaultProxy
  }

  let traderClientConfig =  defaultConfig;

  if (traderClientConfig.proxy == null) {
    traderClientConfig.proxy = defaultProxy
  }

  console.log(traderClientConfig)

  return defineConfig({
    plugins: [react()],
    server: {
      strictPort: true,
      port: traderClientConfig.port,
      proxy: traderClientConfig.proxy
    },
    preview: {
      strictPort: true,
      port: traderClientConfig.port,
      proxy: traderClientConfig.proxy
    }
  })
}