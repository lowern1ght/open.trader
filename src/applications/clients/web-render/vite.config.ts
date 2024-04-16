import react from '@vitejs/plugin-react-swc'
import {TanStackRouterVite} from "@tanstack/router-vite-plugin";
import {CommonServerOptions, defineConfig, loadEnv, ProxyOptions} from 'vite'

const proxyOptions : Record<string, ProxyOptions> = {}

const traderConstants = {
  prefix: 'TRADER_',
  defaultPort: '5030',
  proxyHost: 'http://localhost'
}

export default ({ mode } : { mode: string }) => {
  process.env = {...process.env, ...loadEnv(mode, process.cwd())};
  
  const webApiProxy = {
    key: `/${process.env.TRADER_PROXY_KEY}`,
    replace: `/^\\/${process.env.TRADER_PROXY_KEY}/`
  }
  
  proxyOptions[`${webApiProxy.key}`] = {
    changeOrigin: true,
    target: process.env.TRADER_PROXY_HOST ?? traderConstants.proxyHost,
    rewrite: (path) => path.replace(`/^\\${webApiProxy.replace}/`, ''),
  }
  
  const serverOption : CommonServerOptions = {
    cors: true,
    strictPort: true,
    port: parseInt(process.env.TRADER_PORT ?? traderConstants.defaultPort),
    proxy: proxyOptions
  }
  
  return defineConfig({
    plugins: [react(), TanStackRouterVite()],
    envPrefix: traderConstants.prefix,
    server: serverOption,
    preview: serverOption
  })
}