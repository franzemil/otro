import React from 'react'

export interface TextFieldProps extends React.InputHTMLAttributes<HTMLElement> {
    label: string;
    placeHolder?: string;          
    helpText?: string;
}

export const TextField = ({ label, placeHolder, helpText, ...rest }: TextFieldProps) => {
    return (
        <div className="field">
            <label className="label is-small">{ label }</label>
            <div className="control">
                <input {...rest} className="input is-small" placeholder={placeHolder} />
            </div>
            { helpText && <p className="help is-small">{ helpText }</p>}
        </div>
    )
}
