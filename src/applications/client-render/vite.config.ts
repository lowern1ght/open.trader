import * as fs from "fs";
import * as path from "path";
import react from '@vitejs/plugin-react-swc'
import {defineConfig, loadEnv, ProxyOptions} from 'vite'

const defaultProxy = {
  "/api": {
    changeOrigin: true,
    target: `http://localhost:8001`,
    rewrite: (path) => path.replace(/^\/api/, ''),
  }
}

interface ITraderClientConfig {
  port?: number,
  proxy?: Record<string, string | ProxyOptions>
}

const getTraderClientConfig = () : ITraderClientConfig => {

  fs.readFile(path.join(process.cwd(), 'config', 'trader.config.json'), 'utf8', (err, data) => {
    if (err) {
      return null;
    }

    return  JSON.parse(data) as ITraderClientConfig
  });

  return null
}

export default ({ mode }) => {

  const defaultConfig : ITraderClientConfig = {
    port: 12000,
    proxy: defaultProxy
  }

  let traderClientConfig = getTraderClientConfig() ?? defaultConfig;

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