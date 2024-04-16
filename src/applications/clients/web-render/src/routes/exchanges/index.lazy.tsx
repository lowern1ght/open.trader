import { createLazyFileRoute } from '@tanstack/react-router'
import {ExchangesComponent} from "../../components/ExchangesComponent.tsx";

export const Route = createLazyFileRoute('/exchanges/')({
  component: () => <ExchangesComponent/>
})