import "../styles/index.css"
import {FloatButton} from "antd";
import {Outlet} from "@tanstack/react-router";
import {IdentityProvider} from "./contexts/IdentityProvider.tsx";

//Unused component, use routing or index page
export const RootComponent = () => {
    return (
        <IdentityProvider>
            <>
                <Outlet/>
                <FloatButton.BackTop />
            </>
        </IdentityProvider>
    );
}