import {useState} from "react";
import {ConfigProvider, theme} from "antd";
import {RouterProvider} from "react-router-dom";
import {browserRouter} from "../modules/RouteConfig.tsx";
import {ColorVariant, GlobalConfigProvider, globalTheme} from "../modules/GlobalConfig.ts";


export const AppComponent = () => {
    const [_, setIsDarkMode] = useState("light" as ColorVariant);

    GlobalConfigProvider.setMethodSwitch(setIsDarkMode)

    return (
        <ConfigProvider theme={
            {...globalTheme,
                algorithm: GlobalConfigProvider.isDark() ? theme.darkAlgorithm : theme.defaultAlgorithm
            }}>
            <RouterProvider router={browserRouter}/>
        </ConfigProvider>
    );
};