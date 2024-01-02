import {MainPage} from "../pages/MainPage.tsx";
import {NotFound} from "../pages/NotFound.tsx";
import {LoginPage} from "../pages/LoginPage.tsx";
import {createBrowserRouter} from "react-router-dom";
import {RegisterPage} from "../pages/RegisterPage.tsx";
import {ExchangeChoose} from "../components/exchange/ExchangeChoose.tsx";
import {ExchangePanel} from "../components/exchange/ExchangePanel.tsx";

type RouteConstants = "main" | "login" | "register" | "exchange" | "exchangeChooser"

export const RouteViews : Record<RouteConstants, string> = {
    ['main']: "/",
    ["login"]: "/account/login",
    ["register"]: "/account/register",
    ["exchange"]: "/exchange",
    ["exchangeChooser"]: "/exchange"
}
export const browserRouter = createBrowserRouter([
    {
        path: RouteViews["main"],
        element: <MainPage/>
    },
    {
        path: RouteViews["login"],
        element: <LoginPage/>
    },
    {
        path: RouteViews["register"],
        element: <RegisterPage/>
    },
    {
        path: RouteViews["exchangeChooser"],
        element: <ExchangeChoose/>
    },
    {
      path: RouteViews["exchange"] + '/:name',
      element: <ExchangePanel/>
    },
    {
        path: '*',
        element: <NotFound/>
    }
]);