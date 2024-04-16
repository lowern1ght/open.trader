import {Switch} from "antd";
import React, {useContext} from "react";
import {MoonFilled, SunFilled} from "@ant-design/icons";
import {ThemeContext} from "../contexts/ThemeProvider.tsx";

export interface IThemeSwitcherProps {
    readonly position? : 'right' | 'left';
    readonly linked?: boolean;
}

const leftStyles : React.CSSProperties = {
    left: '20px',
}

const rightStyles : React.CSSProperties = {
    right: '20px',
}

export const ThemeSwitcher = ({ position, linked = true } : IThemeSwitcherProps) => {
    const { isDark, setDark } = useContext(ThemeContext)

    const resultStyle = position == 'right' 
        ? rightStyles 
        : leftStyles
    
    const style : React.CSSProperties = {
        top: '20px',
        position: 'absolute',
        ...resultStyle
    }
    
    return (
        <Switch
            style={linked ? style : {}}
            size={"default"}
            defaultChecked={!isDark}
            checkedChildren={<SunFilled/>}
            unCheckedChildren={<MoonFilled/>}
            onChange={(checked) => setDark(!checked)}
            title={'Theme switcher'}
        />
    );
};