import {isUser} from "../../utilities.ts";
import {useQuery} from "@tanstack/react-query";
import {IUserInfo} from "../../models/identity.ts";
import {fetchUserInfo} from "../../clients/identity.ts";
import {LoadingComponent} from "../LoadingComponent.tsx";
import {createContext, JSX, useEffect, useState} from "react";

export interface IdentityProviderProps {
    user: IUserInfo, 
    setUser: (user: IUserInfo) => void
}

const defaultValue: IdentityProviderProps = {
    user: undefined!,
    setUser: () => {}
}

export const IdentityContext = createContext<IdentityProviderProps>(defaultValue)

export const IdentityProvider = ({ children } : {children: JSX.Element}) => {
    const [user, setCurrentUser] = useState<IUserInfo>();
    const { data: userQuery, isLoading } = useQuery({
        queryKey: ['info'],
        queryFn: () => fetchUserInfo(),
        enabled: user === undefined,
    })
    
    const setUser = (user: IUserInfo) => {
        setCurrentUser(user);
    }
    
    useEffect(() => {
        if (user == undefined && isUser(userQuery)) {
            setUser(userQuery)
        }
    }, [user, userQuery]);

    if (isLoading) {
        return <LoadingComponent/>
    }
    
    if (user != undefined) {
        return (
            <IdentityContext.Provider value={{user, setUser}}>
                {children}
            </IdentityContext.Provider>
        )
    }
    
    if (userQuery != undefined && isUser(userQuery)) {
        return (
            <IdentityContext.Provider value={{user: userQuery, setUser}}>
                {children}
            </IdentityContext.Provider>
        )
    }
    
    return children;
};