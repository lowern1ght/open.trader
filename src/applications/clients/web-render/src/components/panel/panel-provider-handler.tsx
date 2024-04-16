import {JSX} from "react";
import {NotFound} from "../NotFoundComponent.tsx";
import {exchangeNames} from "../../contents/exchange-images/exhange-image-hanlder.tsx";
import {PanelDeribitComponent} from "./providers/Deribit/PanelDeribitComponent.tsx";

export const panelComponentRecord : Record<string, JSX.Element> = {
    [exchangeNames.deribit]: <PanelDeribitComponent/>,
    [exchangeNames.test_deribit]: <PanelDeribitComponent/>
}

export const PanelHandlerComponent = ({ name } : { name: string }) : JSX.Element => {
    const component = undefined //panelComponentRecord[name]

    console.log(`This component provider handler ${name}: ${component}`)
    
    return component != undefined
        ? component 
        : <NotFound
            title={"Component not implemented"} 
            message={'unfortunately, this provider is not implemented, use another one'} 
            buttonTitle={'To exchanges'} 
            pathToReturn={'/exchanges/'}
        />
}