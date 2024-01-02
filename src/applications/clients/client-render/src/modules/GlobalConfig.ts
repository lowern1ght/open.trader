import {theme, ThemeConfig} from "antd";
import {MappingAlgorithm} from "antd/es/theme/interface";

let globalTheme : ThemeConfig = {
    token: {
        colorPrimary: "#33cb92",
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

 export type ColorVariant = "light" | "dark";

function parseAlgorithmToColor(algorithm: MappingAlgorithm) : ColorVariant {
    return algorithm == theme.darkAlgorithm ? "dark" : "light"
}

class GlobalConfigProvider {

    private static method : React.Dispatch<React.SetStateAction<ColorVariant>> | null

    public static setConfig(newTheme: ThemeConfig) {
        globalTheme = newTheme;
        this.switchTheme(parseAlgorithmToColor(globalTheme.algorithm as MappingAlgorithm))
    }

    public static switchTheme(mode: ColorVariant) {
        globalTheme.algorithm = mode == "light"
            ? theme.defaultAlgorithm
            : theme.darkAlgorithm;

        ThemeStorageHelper.save(mode)

        if (this.method != null) {
            this.method(ThemeStorageHelper.isDark() ? "dark" : "light")
        }
    }

    public static isDark() : boolean {
        return ThemeStorageHelper.isDark()
    }

    public static setMethodSwitch(method: React.Dispatch<React.SetStateAction<ColorVariant>>) {
        this.method = method
    }
}

export class ThemeStorageHelper {
    static readonly _color : string = "_cl"
    static readonly _theme : string = "_ctm"

    public static get() : ColorVariant {
        let item = localStorage.getItem(this._color) ?? "light";
        return item == "dark" ? "dark" : "light"
    }

    public static save(color: ColorVariant) {
        localStorage.setItem(this._color, color)
    }

    public static isDark() : boolean {
        return  this.get() == "dark"
    }
}

export { GlobalConfigProvider, globalTheme }