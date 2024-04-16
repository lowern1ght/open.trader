import {Divider, Flex, Layout, Space} from "antd";
import {Header} from "antd/es/layout/layout";
import {toTitleCase} from "../../utilities.ts";
import {useParams} from "@tanstack/react-router";
import {useDocumentTitle} from "@uidotdev/usehooks";
import {NotFound} from "../NotFoundComponent.tsx";
import {UserSubComponent} from "../decoration/UserSubComponent.tsx";
import {ThemeSwitcherRound} from "../decoration/ThemeSwitcherRound.tsx";
import {ExchangesCompactComponent} from "./ExchangesCompactComponent.tsx";
import {panelComponentRecord, PanelHandlerComponent} from "./panel-provider-handler.tsx";

const divideStyle = {margin: '0 15px 0 15px'};

export const PanelExchangeComponent = () => {
    const { internalName } = useParams({ from: '/exchanges/$internalName' })

    useDocumentTitle(`OpenTrader - ${toTitleCase(internalName)}`)
    
    if (panelComponentRecord[internalName] == undefined) {
        return <Layout style={{height: '100dvh'}}>
            <NotFound
                title={'Exchange not exists'}
                message={'By this route not found exchange provider'}
                buttonTitle={'To exchanges'}
                pathToReturn={'/exchanges/'}
            />
        </Layout>
    }
    
    return (
        <Layout style={{ height: '100dvh', width: 'auto' }}>
            <Header>
                <Flex 
                    align={"center"}
                    justify={"flex-end"} 
                    style={{height: '100%'}}
                >
                    <div style={{maxWidth: '300px'}}>
                        
                        {/*<Flex
                            align={"center"}
                            justify={"center"}
                        >
                            
                        </Flex>*/}
                        
                        <Space split={<Divider type={"vertical"} style={divideStyle}/>}>
                            <ExchangesCompactComponent internalName={internalName}/>
                            <ThemeSwitcherRound/>
                            <UserSubComponent/>
                        </Space>
                    </div>
                </Flex>
            </Header>
            <>
                <PanelHandlerComponent name={internalName}/>
            </>
        </Layout>
    );
};