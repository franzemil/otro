import React from 'react'

export interface NavItemProps {
    children: React.ReactNode;
    onClick?: () => void;
    isActive?: boolean;
}

export const NavItem = ({ children, onClick, isActive }: NavItemProps) => {
    return (
        <a className={`navbar-item ` + (isActive ? "is-active" : "")} onClick={onClick}>
            {children}
        </a>
    )
}
