import './index.css'
import React from 'react'
import ReactDOM from 'react-dom/client'
import {AppComponent} from "./components/AppComponent.tsx";
import {useMockAxios} from "./clients/fake.clients.ts";


const dev : boolean = true;
if (dev) useMockAxios()


ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <AppComponent/>
    </React.StrictMode>,
)