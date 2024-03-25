import {useState} from "react";
import {Link, Navigate} from "react-router-dom";
import accountStyles from "./styles/Account.module.css"
import {RouteViews} from "../../modules/RouteConfig.tsx";
import {IRegisterModel} from "../../models/Identity.ts";
import {Button, Card, Divider, Form, Input, Spin, Typography} from "antd";
import {IAccountComponent} from "../../interfaces/IAccountComponent.tsx";
import {LockOutlined, MailOutlined, UserOutlined} from "@ant-design/icons";
import {IdentityClient} from "../../clients/identity.client.ts";

export const RegisterComponent = () : IAccountComponent => {
    const [loading, setLoading] = useState(false)
    const [isRegistered, setRegister] = useState(false)

    const onFinish = async (model: IRegisterModel) => {
        setLoading(true)

        IdentityClient.RegisterAsync(model)
            .then(_ => setRegister(true))
        
        setLoading(false)
    }

    if (isRegistered) {
        return <Navigate to={RouteViews["login"]} replace={true}/>
    }

    return (

        <Card className={accountStyles.form}>
            <Spin spinning={loading} size={"large"}>

                <Typography.Title className={accountStyles.title_text}>
                    Register In
                </Typography.Title>

                <Form
                    name="normal_login"
                    className="login-form"
                    style={{width: 250}}
                    initialValues={{ remember: true }}
                    onFinish={onFinish}
                >
                    <Form.Item
                        name="email"
                        rules={[{ required: true, message: 'Please input your Email!' }]}
                    >
                        <Input prefix={<MailOutlined className="site-form-item-icon" />} placeholder="Email" />
                    </Form.Item>

                    <Form.Item
                        name="username"
                        rules={[{ required: true, message: 'Please input your Username!' }]}
                    >
                        <Input prefix={<UserOutlined className="site-form-item-icon" />} placeholder="Username" />
                    </Form.Item>

                    <Form.Item
                        name="password"
                        rules={[{ required: true, message: 'Please input your Password!' }]}
                    >
                        <Input
                            prefix={<LockOutlined className="site-form-item-icon" />}
                            type="password"
                            placeholder="Password"
                        />
                    </Form.Item>

                    <Form.Item
                        name="passwordConfirm"
                        rules={[ {required: true, message: 'Please input Password!'},
                            ({getFieldValue}) => ({
                                validator(_, value) {
                                    if (!value || getFieldValue('password') === value) {
                                        return Promise.resolve();
                                    }

                                    return Promise.reject(new Error('The new password that you entered do not match!'));
                                }})]}
                    >
                        <Input
                            prefix={<LockOutlined className="site-form-item-icon" />}
                            type="password"
                            placeholder="Confirm password"
                        />
                    </Form.Item>

                    <Divider style={{margin: 10}}/>

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
                            Register
                        </Button>

                        <Typography.Text style={{height: 'auto'}}>
                            Or
                        </Typography.Text>

                        <Link to={RouteViews["login"]}>
                            <Typography.Link>login now</Typography.Link>
                        </Link>

                    </div>
                </Form>
            </Spin>
        </Card>
    )
};