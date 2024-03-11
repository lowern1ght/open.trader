import react from '@vitejs/plugin-react-swc'
import mkcert from 'vite-plugin-mkcert'
import {defineConfig, loadEnv, ProxyOptions} from 'vite'

const defaultProxy = {
  "/web-api": {
    changeOrigin: true,
    target: `http://localhost:5001`,
    rewrite: (path) => path.replace(/^\/web-api/, ''),
  }
}

interface ITraderClientConfig {
  port?: number,
  proxy?: Record<string, string | ProxyOptions>
}

export default ({ mode }) => {

  const defaultConfig : ITraderClientConfig = {
    port: 6000,
    proxy: defaultProxy
  }

  let traderClientConfig =  defaultConfig;

  if (traderClientConfig.proxy == null) {
    traderClientConfig.proxy = defaultProxy
  }

  console.log(traderClientConfig)

  return defineConfig({
    plugins: [react(), mkcert()],
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