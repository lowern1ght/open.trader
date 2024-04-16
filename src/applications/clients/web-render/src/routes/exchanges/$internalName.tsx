import { createFileRoute } from '@tanstack/react-router'
import {PanelExchangeComponent} from "../../components/panel/PanelExchangeComponent.tsx";

export const Route = createFileRoute('/exchanges/$internalName')({
  component: () => <PanelExchangeComponent/>
})