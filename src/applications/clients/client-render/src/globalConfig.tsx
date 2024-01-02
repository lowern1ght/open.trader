import {theme, ThemeConfig} from "antd";

const themeColorName = "_cth"
const themePropertyName = "_th"

export let defaultTheme : ThemeConfig = {
    token: {
        colorPrimary: "#72CEAB",
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
    },

    algorithm: theme.darkAlgorithm
}

export const getConfig = () : ThemeConfig => {

    let color = localStorage.getItem(themeColorName)
    let item = localStorage.getItem(themePropertyName)

    if (item != null && item.length > 0) {
        let parse = JSON.parse(item) as ThemeConfig;

        if (color != null && color == "light" || color == "dark") {
            parse.algorithm = color == "light"
                ? theme.defaultAlgorithm
                : theme.darkAlgorithm
        }
        else {
            parse.algorithm = theme.defaultAlgorithm
            localStorage.setItem(themeColorName, "light")
        }

        return parse
    }
    else {
        localStorage.setItem(themePropertyName, JSON.stringify(defaultTheme))
    }

    return defaultTheme;
}

export const setTheme = (theme: "light" | "dark") => {
    localStorage.setItem(themeColorName, theme)
}