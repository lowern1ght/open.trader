import 'antd/dist/reset.css'
import 'antd/lib/'
import "./styles/index.css";
import ReactDOM from 'react-dom/client';
import {isDevelop} from "./utilities.ts";
import {routeTree} from './routeTree.gen';
import {queryClient} from "./clients/general.ts";
import {QueryClientProvider} from "@tanstack/react-query";
import {initializeMock} from "./clients/general.mock.ts";
import {createRouter, RouterProvider} from "@tanstack/react-router";
import {ThemeProvider} from "./components/contexts/ThemeProvider.tsx";
import {UnsupportedDetector} from "./components/unsupported/UnsupportedDetector.tsx";
import {MobileDeniedComponent} from "./components/unsupported/MobileDeniedComponent.tsx";
import {OldBrowserDeniedComponent} from "./components/unsupported/OldBrowserDeniedComponent.tsx";

const router = createRouter({routeTree})

if (isDevelop()) {
    console.log(`Application version: ${import.meta.env.TRADER_REACT_APP_VERSION} is started ❤`)

    console.log(import.meta.env)
    
    if (import.meta.env.TRADER_USE_MOCK_AXIOS == 'true') {
        console.log(`Initialize mock axios ⛷`)
        try {
            initializeMock()
        }
        catch (error) {
            console.warn(`Failed to initialize mock axios, failed with error`);
            console.error(error);
        }
    }
}

ReactDOM.createRoot(document.getElementById('root')!).render(
    <>
        <QueryClientProvider client={queryClient}>
            <ThemeProvider>
                <UnsupportedDetector
                    mobile={<MobileDeniedComponent/>}
                    oldBrowser={<OldBrowserDeniedComponent/>}
                >
                    <RouterProvider router={router} />
                </UnsupportedDetector>
            </ThemeProvider>
        </QueryClientProvider>
    </>
);