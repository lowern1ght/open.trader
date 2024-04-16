import {JSX} from "react";
import {exchangesLogoRecord} from "./exhange-image-hanlder";
import {ExclamationCircleOutlined} from "@ant-design/icons";

export const ExchangeIcon = ({ name } : { name: string }) => {
    const logoElement : JSX.Element | undefined = exchangesLogoRecord[name];

    return logoElement == undefined
        ? <ExclamationCircleOutlined style={{color: 'yellow'}}/>
        : logoElement;
};