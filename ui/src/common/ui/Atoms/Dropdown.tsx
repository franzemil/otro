export interface DropdownProps {
    label: string
}

export const Dropdown = ({}: DropdownProps) =>
    <div className="dropdown">
        <div className="dropdown-trigger">
            <div className="button">
                <span></span>
            </div>
        </div>
    </div>