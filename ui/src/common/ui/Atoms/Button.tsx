export interface ButtonProps {
    text: string;
    onClick: () => void;
    primary: boolean;
}

export const Button = ({text, onClick, primary}: ButtonProps) => 
    <button className={`button ${primary ? 'is-primary' : ''}`} onClick={(_) => onClick()}>{ text }</button>