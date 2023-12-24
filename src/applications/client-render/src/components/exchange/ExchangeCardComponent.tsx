import Meta from "antd/es/card/Meta";
import parse from 'html-react-parser';
import {Link} from "react-router-dom";
import {useEffect, useState} from "react";
import styles from "./styles/ExchangeCard.module.css"
import {RouteViews} from "../../modules/RouteConfig.tsx";
import {Avatar, Card, Result, Spin, Typography} from "antd";
import {ExchangeClient} from "../../clients/ExchangeClient.ts";
import {IssuesCloseOutlined, LockOutlined} from "@ant-design/icons";
import {ExchangeModel} from "../../clients/models/ExchangeModels.ts";

export const ExchangeCardComponent = ({exchange}: { exchange: ExchangeModel }) => {
    const [image, setImage] = useState("")
    const [isError, setError] = useState(false)

    useEffect(() => {
        ExchangeClient.imageById(exchange.id)
            .then(data => {
                setImage(data)
            })
            .catch(() => setError(true))
    }, []);

    if (isError) {
        return (
            <Card title={<IssuesCloseOutlined /> + "Error"}>
                <Result title={"Error get exchange"} icon={<LockOutlined/>} />
            </Card>
        )
    }

    return (
        <Spin spinning={image.length == 0} size={"default"}>
            <Card
                title={exchange.title}
                className={styles.exchange_container}
                extra={
                    <Link to={RouteViews["exchange"] + `/${exchange.title}`} replace>
                        <Typography.Link>
                            Choose
                        </Typography.Link>
                    </Link>
                }
            >
                <Meta
                    avatar={<Avatar src={SvgIconFromString(image)} shape={"square"}/>}
                    description={exchange.baseUrl}/>
            </Card>
        </Spin>
    )
}

const SvgIconFromString = (data: string) => {
    return (
        <span style={{width: 'auto', height: 'auto'}}>
            {parse(data)}
        </span>
    )
}