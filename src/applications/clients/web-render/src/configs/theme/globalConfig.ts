import {ThemeConfig} from "antd";

export const globalTheme : ThemeConfig = {
    token: {
        colorPrimary: "#bfd67c", //"#33cb92",
        boxShadow: '\\n 0 8px 20px 0 rgba(0, 0, 0, 0.08),' +
            ' \\n 0 3px 6px -4px rgba(0, 0, 0, 0.12), ' +
            '\\n 0 9px 28px 8px rgba(0, 0, 0, 0.05)',
        borderRadius:4,
        wireframe: true
    },

    components: {
        Button: {
            algorithm: true
        }
    }
}