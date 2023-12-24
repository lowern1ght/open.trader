import './index.css'
import React from 'react'
import ReactDOM from 'react-dom/client'
import {AppComponent} from "./components/AppComponent.tsx";

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <AppComponent/>
    </React.StrictMode>,
)

