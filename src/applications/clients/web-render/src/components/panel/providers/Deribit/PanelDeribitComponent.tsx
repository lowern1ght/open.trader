import {useContext} from "react";
import {Layout} from "antd";
import {ThemeContext} from "../../../contexts/ThemeProvider.tsx";

export const PanelDeribitComponent = () => {
    const {isDark} = useContext(ThemeContext);
    
    return (
        <Layout>
            {isDark}
        </Layout>
    );
};