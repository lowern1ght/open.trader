import {exchangeNames} from "../exhange-image-hanlder";
import TestDeribitSvgFile from "../../resources/deribit-test.svg";

export const TestDeribitLogo = () => {
    return (
        <img src={TestDeribitSvgFile} alt={exchangeNames.deribit}></img>
    );
};