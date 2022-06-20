import React from 'react'
import { Logo } from '../Atoms/Logo';
import { NavItem } from '../Atoms/navitem';

export const NavBar = () => {
    return (
            <nav className="navbar is-spaced">
                <div className="navbar-brand">
                    <a className="navbar-item">
                        <Logo />
                    </a>
                    <span className="navbar-burger burger" data-target="navbarMenu">
                        <span></span>
                        <span></span>
                        <span></span>
                    </span>
                </div>
                <div id="navbarMenu" className="navbar-menu">
                    <div className="navbar-end">
                        <NavItem isActive>
                            Facturacion
                        </NavItem>
                        <NavItem>
                            Gestion
                        </NavItem>
                        <NavItem>
                            Documentation
                        </NavItem>
                    </div>
                </div>
            </nav>
    )
}
