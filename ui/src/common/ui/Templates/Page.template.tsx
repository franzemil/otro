import { ReactNode } from "react";

export interface PageTemplateProps {
    children: ReactNode;
}

export const PageTemplate = ({ children }: PageTemplateProps) =>
    <div className="container">
        { children }
    </div>