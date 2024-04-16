import {JSX} from "react";
import Meta from "antd/es/card/Meta";
import {Avatar, Card, Tooltip} from "antd";
import {Link} from "@tanstack/react-router";
import {IExchange} from "../models/exchange.ts";
import styles from "./styles/ItemExchange.module.css"
import {ArrowRightOutlined, ExportOutlined} from "@ant-design/icons";
import {ExchangeIcon} from "../contents/exchange-images/ExchangeIcon.tsx";

export const ItemExchangeComponent = ({exchange}: { exchange: IExchange }) => {
    
    const actions : JSX.Element[] = [
        <Tooltip key={`panel`} title={`Go to ${exchange.internalName} panel`}>
            <Link
                to='/exchanges/$internalName'
                params={{internalName: exchange.internalName}}
            >
                <ArrowRightOutlined />
            </Link>
        </Tooltip>,
        
        <Tooltip key={'official'} title={`Open site ${exchange.baseUrl}`}>
            <Link to={`https://${exchange.baseUrl}`}>
                <ExportOutlined />
            </Link>
        </Tooltip>
    ]
    
    return (
        <Card
            title={exchange.title}
            className={styles.exchange_container}
            actions={actions}
        >
            <Meta
                description={exchange.baseUrl}
                avatar={
                <Avatar
                    shape={"square"}
                    src={<ExchangeIcon name={exchange.internalName}/>}
                />}
            />
        </Card>
    )
}