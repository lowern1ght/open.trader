import {JSX} from "react";
import {DeribitLogo} from "./components/DeribitLogo";
import {TestDeribitLogo} from "./components/TestDeribitLogo";

export const exchangeNames = {
    deribit: "deribit",
    test_deribit: "test-deribit",
}

export const exchangesLogoRecord : Record<string, JSX.Element> = {
    [exchangeNames.deribit] : <DeribitLogo/>,
    [exchangeNames.test_deribit] : <TestDeribitLogo/>,
}