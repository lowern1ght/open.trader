import {Navigate} from "react-router-dom";
import {RouteViews} from "../modules/RouteConfig.tsx";
import {TraderAuthorizeProvider} from "./account/TraderAuthorizeProvider.tsx";
import {JSX} from "react";
import {LoadingPage} from "../pages/LoadingPage.tsx";

export const DefaultAuthorizeComponent = ({ children } : { children: JSX.Element }) => {
    return (
        <TraderAuthorizeProvider loginPage={<Navigate to={RouteViews["login"]} replace={true}/>} loadingPage={<LoadingPage/>}>
            {children}
        </TraderAuthorizeProvider>
    );
};