import {JSX} from "react";
import {Typography} from "antd";
import {exchangesLogoRecord} from "./exhange-image-hanlder";

export const ExchangeIcon = ({ name } : { name: string }) => {
    const logoElement : JSX.Element | undefined = exchangesLogoRecord[name];

    return logoElement == undefined
        ? <Typography.Text>Nothing</Typography.Text> : (
        logoElement
    );
};