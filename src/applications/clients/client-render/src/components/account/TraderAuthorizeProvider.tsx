import {JSX, useEffect, useState} from "react";
import {IdentityClient} from "../../clients/identity.client.ts";

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
            IdentityClient.UserInfoAsync()
                .then(_ => setLogin(true))
            
            setNeedLogin(true)
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