import {exchangeNames} from "../exhange-image-hanlder";
import DeribitSvgFile from "../../resources/deribit.svg"

export const DeribitLogo = () => {
    return (
        <img src={DeribitSvgFile} alt={exchangeNames.deribit}></img>
    );
};