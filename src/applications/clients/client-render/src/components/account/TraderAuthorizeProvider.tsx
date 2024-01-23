import {JSX, useEffect, useState} from "react";
import {IdentityHelper} from "../../clients/webApiClients.ts";

export interface ITraderAuthorizeProvider {
    children: JSX.Element | JSX.Element[],
    loginPage: JSX.Element,
    loadingPage: JSX.Element
}

export const TraderAuthorizeProvider = ({ children, loadingPage, loginPage } : ITraderAuthorizeProvider) => {
    const [isLogin, setLogin] = useState(false)
    const [needLogin, setNeedLogin] = useState(false)

    useEffect(() => {
        setTimeout(() => {
            IdentityHelper.isAuthorize()
                .then(result => !result
                    ? setNeedLogin(true)
                    : setLogin(true))
                .catch(() => setNeedLogin(true))
        }, 2000)
    }, []);

    if (isLogin) {
        return children
    }

    if (needLogin) {
        return  loginPage
    }

    return loadingPage
};