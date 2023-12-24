import {useEffect, useState} from "react";
import {Link, Navigate} from "react-router-dom";
import accountStyles from "./styles/Account.module.css"
import {RouteViews} from "../../modules/RouteConfig.tsx";
import {LockOutlined, MailOutlined} from "@ant-design/icons";
import {IAccountComponent} from "../../interfaces/IAccountComponent.tsx";
import {IdentityClient, IdentityHelper} from "../../clients/IdentityClient.ts";
import {Button, Card, Checkbox, Divider, Form, Input, notification, Spin, Typography} from "antd";
import {IUserLogin} from "../../models/Identity.ts";

export const LoginComponent = () : IAccountComponent => {
    const [isLogin, setLogin] = useState(false)
    const [loading, setLoading] = useState(false)
    const [isAuthorize, setAuthorize] = useState(false)
    const [api, contextHolder] = notification.useNotification();

    useEffect(() => {
        IdentityHelper.isAuthorize()
            .then(value => setAuthorize(value))
    }, []);

    const onFinish = async (model: IUserLogin) => {
        setLoading(true)

        try {
            let response = await IdentityClient.login(model);

            if (response.status == 200)
                setLogin(true)
        }
        catch {
            api.error({
                message: 'Error sign in',
                description: "Password or Email uncorrected"

            });
        }
        finally {
            setLoading(false)
        }
    }

    if (isLogin || isAuthorize) {
        return <Navigate to={RouteViews["loading"]}/>
    }

    return (
        <Card className={accountStyles.form}>

            {contextHolder}

            <Spin spinning={loading} size={"large"}>

                <Typography.Title className={accountStyles.title_text}>
                    Sign In
                </Typography.Title>

                <Form
                    name="normal_login"
                    className="login-form"
                    style={{width: 250}}
                    initialValues={{remember: true}}
                    onFinish={onFinish}
                >
                    <Form.Item
                        name="email"
                        rules={[{required: true, message: 'Please input your Email!'}]}
                    >
                        <Input prefix={<MailOutlined className="site-form-item-icon"/>} placeholder="Email"/>
                    </Form.Item>

                    <Form.Item
                        name="password"
                        rules={[{required: true, message: 'Please input your Password!'}]}
                    >
                        <Input
                            prefix={<LockOutlined className="site-form-item-icon"/>}
                            type="password"
                            placeholder="Password"
                        />
                    </Form.Item>

                    <Form.Item>
                        <Form.Item name="rememberMe" valuePropName="checked" noStyle>
                            <Checkbox>Remember me</Checkbox>
                        </Form.Item>
                    </Form.Item>

                    <Divider style={{margin: 10}}></Divider>

                    <div style={
                        {
                            display: 'flex',
                            flexDirection: 'row',
                            alignItems: 'center',
                            alignSelf: 'center',
                            justifyContent: 'space-between',
                        }}>

                        <Button
                            type="primary"
                            htmlType="submit"
                            style={{width: 100}}
                            className="login-form-button">
                            Log in
                        </Button>

                        <Typography.Text style={{height: 'auto'}}>
                            Or
                        </Typography.Text>

                        <Link to={RouteViews["register"]}>
                            <Typography.Link>register now</Typography.Link>
                        </Link>
                    </div>

                </Form>
            </Spin>
        </Card>
    );
};