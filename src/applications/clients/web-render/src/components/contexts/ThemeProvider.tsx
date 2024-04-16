import {ConfigProvider, theme} from "antd";
import { useLocalStorage } from 'usehooks-ts'
import {createContext, JSX, useState} from "react";
import {globalTheme} from "../../configs/theme/globalConfig.ts";

const localKey = '_.dr_c'

export interface ThemeProviderProps {
    isDark: boolean,
    setDark: (isDark: boolean) => void
}

const defaultValue: ThemeProviderProps = { 
    isDark: false, 
    setDark: () => {}
}

export const ThemeContext = createContext<ThemeProviderProps>(defaultValue);

export const ThemeProvider = ({ children } : { children: JSX.Element}) => {
    const [value, setValue] = useLocalStorage(localKey, false)
    const [isDark, setDarkState] = useState(value);
    
    const setDark = (isDark: boolean) => {
        setValue(isDark)
        setDarkState(isDark);
    }
    
    return (
        <ThemeContext.Provider value={{isDark, setDark}}>
            <ConfigProvider theme={
                {...globalTheme,
                    algorithm: isDark
                        ? theme.darkAlgorithm
                        : theme.defaultAlgorithm
                }}
            >
                {children}
            </ConfigProvider>
        </ThemeContext.Provider>
    );
};