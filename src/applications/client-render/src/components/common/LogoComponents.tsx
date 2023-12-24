import React from "react";
import logoSvg from "../../assets/max_icon.svg";
import {Typography} from "antd";

const style: React.CSSProperties = {
    textAlign: 'center',
    display: 'flex',
    alignItems: 'center',
    flex: 'auto',
    justifyContent: 'center',
    flexDirection: 'row',
    width: '100%'
}

const commonTextStyle : React.CSSProperties = {
    fontFamily: 'Afacad',
    fontSize: "2em",
}

export const LogoComponents = ({ height } : { height: string }) => {
    return (
        <div style={{height, ...style }}>
            <img src={logoSvg} alt="logo" style={{ height, width: height }}/>
            <Typography.Text color={"neutral"} style={{...commonTextStyle}}>Trader</Typography.Text>
            <Typography.Text style={{...commonTextStyle, marginLeft: '8px', marginRight: '8px', opacity: '0.5'}}>|</Typography.Text>
            <Typography.Text style={{...commonTextStyle, color: '#ff0073'}}>Platform</Typography.Text>
        </div>
    );
};

export const CompactLogo = ({ height, width, textColor } : { height: string, width: string, textColor: string }) => {
    return (
        <div
            style={{
                height,
                display: 'flex',
                flexDirection: 'row',
                justifyItems: 'center',
                justifyContent: 'center',
                textAlign: 'center',
                alignItems: 'center'
            }}
        >
            <img src={logoSvg} alt="logo" style={{ height, width: width }}/>
            <Typography.Text color={textColor} style={{...commonTextStyle}}>Trader</Typography.Text>
        </div>
    );
};