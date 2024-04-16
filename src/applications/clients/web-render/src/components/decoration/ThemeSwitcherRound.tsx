import {Button} from "antd";
import {useContext} from "react";
import {MoonFilled, SunFilled} from "@ant-design/icons";
import {ThemeContext} from "../contexts/ThemeProvider.tsx";

export const ThemeSwitcherRound = () => {
    const { isDark, setDark } = useContext(ThemeContext)
    
    return (
        <Button
            size={"middle"}
            shape={"circle"}
            icon={isDark ? <SunFilled /> : <MoonFilled />}
            onClick={() => setDark(!isDark)}
        />
    );
};