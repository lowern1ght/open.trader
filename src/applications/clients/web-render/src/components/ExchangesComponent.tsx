import {Content} from "antd/es/layout/layout";
import {useQuery} from "@tanstack/react-query";
import {EmptyData} from "./other/EmptyData.tsx";
import {LoadingOutlined} from "@ant-design/icons";
import styles from './styles/Exchanges.module.css'
import {ErrorComponent} from "./ErrorComponent.tsx";
import {fetchExchangesList} from "../clients/exchange.ts";
import {ThemeSwitcher} from "./decoration/ThemeSwitcher.tsx";
import {ItemExchangeComponent} from "./ItemExchangeComponent.tsx";
import {LogoComponent} from "./decoration/WhiteLabelsComponent.tsx";
import {Col, Divider, Layout, Row, Space, Spin, Result} from "antd";


export const ExchangesComponent = () => {
    const { error, data: exchanges, isLoading } = useQuery({ 
        queryKey: ['exchanges'], 
        queryFn: fetchExchangesList
    })
    
    if (error) {
        return <ErrorComponent error={error} reset={console.clear}/>
    }
    
    return (
        <Layout className={styles.layout}>
            <Space className={styles.space_main}>
                <LogoComponent size={'40px'} withDivide={false}/>
                <ThemeSwitcher position={"right"}/>
            </Space>

            <Divider>Exchanges</Divider>
            
            <Content className={styles.content_exchanges}>
                <Spin
                    fullscreen
                    spinning={isLoading}
                    indicator={<LoadingOutlined style={{fontSize: '100px', opacity: '.4'}}/>}
                />

                <Row gutter={[16, 16]} justify={"space-evenly"}>
                    {
                        isLoading ? <EmptyData/> : exchanges && exchanges?.length > 0
                            ? exchanges?.map((exchange, index) => {
                                return (
                                    <Col key={index} span={12}>
                                        <ItemExchangeComponent exchange={exchange}/>
                                    </Col>)
                            })
                            : <Result
                                status={"warning"}
                                title={"Exchanges is empty"}
                                subTitle={'There are no supported providers'}
                            />
                    }
                </Row>
            </Content>
        </Layout>
    )
};

