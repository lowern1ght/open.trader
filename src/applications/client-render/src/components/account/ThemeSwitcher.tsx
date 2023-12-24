import {Switch} from "antd";
import {CSSProperties, useState} from "react";
import {BulbFilled, BulbOutlined} from "@ant-design/icons";
import {GlobalConfigProvider} from "../../modules/GlobalConfig.ts";

export const ThemeSwitcher = ({ styleChild } : { styleChild?: CSSProperties }) => {
    const [isDark, setDark] = useState(GlobalConfigProvider.isDark())

    return (
        <Switch
            size={"default"}
            defaultChecked={!isDark}
            checkedChildren={<BulbFilled />}
            unCheckedChildren={<BulbOutlined />}

            onChange={(checked) => {
                GlobalConfigProvider.switchTheme(checked ? "light" : "dark")
                setDark(checked)
            }}

            style={styleChild ?? {
                margin: '20px',
                position: 'absolute',
            }}
        />
    );
};