import {Link} from "@tanstack/react-router";
import {useQuery} from "@tanstack/react-query";
import {Avatar, Button, List, Popover} from "antd";
import styles from '../styles/ExchangeCompact.module.css'
import {fetchExchangesList} from "../../clients/exchange.ts";
import {AppstoreOutlined, RightOutlined} from "@ant-design/icons";
import {ExchangeIcon} from "../../contents/exchange-images/ExchangeIcon.tsx";

const ListExchangesComponent = ({ internalName } : { internalName: string } ) => {
    const { data: exchangesList, isLoading } = useQuery({
        queryKey: ['exchangeList'],
        queryFn: fetchExchangesList
    })
    
    return (
        <>
            <div className={styles.popover_content}>
                <List
                    loading={isLoading}
                    dataSource={exchangesList?.filter(item => item.internalName != internalName) ?? []}
                    renderItem={(item, index) => (
                        <div key={index}>
                            <List.Item
                                actions={[
                                    <Link key={'to-exchanges'} to={`/exchanges/${item.internalName}`}>
                                        <RightOutlined />
                                    </Link>
                                ]}
                            >
                                <List.Item.Meta
                                    title={item.title}
                                    description={item.baseUrl}
                                    avatar={<Avatar
                                        shape={"square"}
                                        src={<ExchangeIcon name={item.internalName}/>}
                                    />}
                                />
                            </List.Item>
                        </div>
                    )}
                />
            </div>
        </>
    )
}

export const ExchangesCompactComponent = ({internalName}: { internalName: string }) => {
    return (
        <div>
            <Popover
                content={<ListExchangesComponent internalName={internalName}/>}
            >
                <Button icon={<AppstoreOutlined />}/>
            </Popover>
        </div>
    );
};