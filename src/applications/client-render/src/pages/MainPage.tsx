import "./styles/MainPage.css"
import {Navigate} from "react-router-dom";
import {RouteViews} from "../modules/RouteConfig.tsx";
import {TraderAuthorizeProvider} from "../components/account/TraderAuthorizeProvider.tsx";
import {LoadingPage} from "./LoadingPage.tsx";
import {ExchangeChoose} from "../components/exchange/ExchangeChoose.tsx";

export const MainPage = () => {
    return (
        <TraderAuthorizeProvider
            loginPage={<Navigate to={RouteViews["login"]} replace={true}/>}
            loadingPage={<LoadingPage/>}
        >
            <ExchangeChoose/>
        </TraderAuthorizeProvider>
    )
};

