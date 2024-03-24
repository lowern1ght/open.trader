import Meta from "antd/es/card/Meta";
import {Link} from "react-router-dom";
import styles from "./styles/ExchangeCard.module.css"
import {RouteViews} from "../../modules/RouteConfig.tsx";
import {Avatar, Card, Result, Spin, Typography} from "antd";
import {useExchangeImage} from "../../hooks/webApiClients.ts";
import {IssuesCloseOutlined, LockOutlined} from "@ant-design/icons";
import {ExchangeModel} from "../../clients/models/ExchangeModels.ts";

export const ExchangeCardComponent = ({exchange}: { exchange: ExchangeModel }) => {
    const { data, error, isLoading } = useExchangeImage(exchange.id)

    if (error != undefined) {
        return (
            <Card title={<IssuesCloseOutlined /> + "Error"}>
                <Result title={"Error get exchange"} icon={<LockOutlined/>} />
            </Card>
        )
    }

    return (
        <Spin spinning={isLoading} size={"default"}>
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
                    avatar={<Avatar src={data} shape={"square"}/>}
                    description={exchange.baseUrl}/>
            </Card>
        </Spin>
    )
}