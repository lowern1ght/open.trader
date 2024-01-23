import {Content, Footer} from "antd/es/layout/layout";
import {ThemeSwitcher} from "../account/ThemeSwitcher.tsx";
import {LogoComponents} from "../common/LogoComponents.tsx";
import {useExchanges} from "../../clients/webApiClients.ts";
import {ExchangeCardComponent} from "./ExchangeCardComponent.tsx";
import {Col, Divider, Layout, Row, Space, Spin, Typography, FloatButton, Result} from "antd";

export const ExchangeChoose = () => {
    const { data, error, isLoading } = useExchanges()

    if (error) {
        return <Result
            title={error.name}
            status={"error"}
            subTitle={error.message}
        />
    }

    return (
        <Layout style={{height: '100%'}}>
            <Space style={{width: '100%', height: '80px', padding: '10px', justifyContent: 'space-between'}}>
                <LogoComponents height={'60px'}/>
                <ThemeSwitcher styleChild={{marginRight: '20px'}}/>
            </Space>

            <Content style={{padding: '20px', marginTop: '20px'}}>

                <Space
                    align={"center"}
                    style={{width: '100%', display: 'flex'}}
                >
                    <Typography.Text style={{opacity: '0.7', textAlign: 'center', fontSize: '24px'}}>
                        * To start trading later, you need to choose an available cryptocurrency service provider
                    </Typography.Text>
                </Space>

                <Divider>Exchanges</Divider>

                <Spin spinning={isLoading} size={"large"}>
                    <Row wrap style={{ display: 'flex', justifyContent: 'space-evenly', width: '100%' }}>
                        {data != undefined
                            ? data.map((model, index) => {
                                return (
                                    <Col key={index} span={'auto'} flex={'auto'} style={{margin: '10px'}}>
                                        <ExchangeCardComponent exchange={model}/>
                                    </Col>)
                                })
                            : <div>Ops... some wrong</div>
                        }
                    </Row>
                </Spin>
            </Content>

            <Footer>
                <Typography.Text style={{ opacity: '.5' }}>
                    if need more exchange provider, send to me
                    <Typography.Text type={"secondary"}>
                        <strong> @lowern1ght</strong>
                    </Typography.Text>
                </Typography.Text>
            </Footer>

            <FloatButton.BackTop />

        </Layout>
    )
};

