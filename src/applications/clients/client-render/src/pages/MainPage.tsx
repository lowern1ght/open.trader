import "./styles/MainPage.css"
import {Navigate} from "react-router-dom";
import {LoadingPage} from "./LoadingPage.tsx";
import {RouteViews} from "../modules/RouteConfig.tsx";
import {TraderAuthorizeProvider} from "../components/account/TraderAuthorizeProvider.tsx";

export const MainPage = () => {
    return (
        <TraderAuthorizeProvider
            loginPage={<Navigate to={RouteViews["login"]} replace={true}/>}
            loadingPage={<LoadingPage/>}
        >
            <Navigate to={RouteViews["exchangeChooser"]}/>
        </TraderAuthorizeProvider>
    )
};