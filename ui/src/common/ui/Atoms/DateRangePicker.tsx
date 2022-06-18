import { addDays } from 'date-fns';
import { es } from 'date-fns/locale';
import { useEffect, useState } from 'react';
import { DateRangePicker as DRP, RangeKeyDict } from 'react-date-range';
import 'react-date-range/dist/styles.css'; // main css file
import 'react-date-range/dist/theme/default.css'; // theme css file
import "./daterangepicker.scss"

import {
    endOfDay,
    startOfDay,
    startOfMonth,
    endOfMonth,
    addMonths,
    startOfWeek,
    endOfWeek,
    isSameDay,
} from 'date-fns';

const defineds = {
    startOfWeek: startOfWeek(new Date()),
    endOfWeek: endOfWeek(new Date()),
    startOfLastWeek: startOfWeek(addDays(new Date(), -7)),
    endOfLastWeek: endOfWeek(addDays(new Date(), -7)),
    startOfToday: startOfDay(new Date()),
    endOfToday: endOfDay(new Date()),
    startOfYesterday: startOfDay(addDays(new Date(), -1)),
    endOfYesterday: endOfDay(addDays(new Date(), -1)),
    startOfMonth: startOfMonth(new Date()),
    endOfMonth: endOfMonth(new Date()),
    startOfLastMonth: startOfMonth(addMonths(new Date(), -1)),
    endOfLastMonth: endOfMonth(addMonths(new Date(), -1)),
};

export interface DateRange {
    startDate: Date,
    endDate: Date
}

export interface DateRangePickerProps {
    dates: DateRange
    setDates: (dates: DateRange) => void
}

export const DateRangePicker = ({ dates, setDates }: DateRangePickerProps) => {
    const [state, setState] = useState([
        {
            startDate: dates.startDate || new Date(),
            endDate: dates.endDate || addDays(new Date(), 1),
            key: 'selection'
        }
    ]);

    useEffect(() => {
        setDates(state[0])
    }, [state, setDates])

    return (
        <DRP
            onChange={(date: RangeKeyDict) => setState([date["selection"] as any])}
            moveRangeOnFirstSelection={false}
            months={1}
            ranges={state}
            direction="horizontal"
            locale={es}
            showDateDisplay={false}
            showPreview={false}
            showMonthArrow={false}
            inputRanges={[]}
            className='crp'
            classNames={
                {
                    day: 'crp-day--active',
                    dateDisplay: 'franz',
                    dateDisplayItem: 'franz',
                    dayActive: 'crp-day--active',
                    daySelected: 'crp-day--active',
                    dayHovered: 'crp-day--active',
                    dayPassive: 'crp-day--active',
                    staticRanges: 'crp-day--active',
                    staticRangeLabel: 'crp-day--active',
                    staticRangeSelected: 'red',
                }}
            staticRanges={[
                {
                    label: 'Hoy',
                    range: () => ({
                        startDate: defineds.startOfToday,
                        endDate: defineds.endOfToday,
                    }),
                    isSelected(range) {
                        const definedRange = this.range();
                        return (
                            isSameDay(range.startDate as Date, definedRange.startDate as Date) &&
                            isSameDay(range.endDate as Date, definedRange.endDate as Date)
                        );
                    },
                },
                {
                    label: 'Esta Semana',
                    range: () => ({
                        startDate: defineds.startOfWeek,
                        endDate: defineds.endOfWeek,
                    }),
                    isSelected(range) {
                        const definedRange = this.range();
                        return (
                            isSameDay(range.startDate as Date, definedRange.startDate as Date) &&
                            isSameDay(range.endDate as Date, definedRange.endDate as Date)
                        );
                    },
                },
                {
                    label: 'Este Mes',
                    range: () => ({
                        startDate: defineds.startOfMonth,
                        endDate: defineds.endOfMonth,
                    }),
                    isSelected(range) {
                        const definedRange = this.range();
                        return (
                            isSameDay(range.startDate as Date, definedRange.startDate as Date) &&
                            isSameDay(range.endDate as Date, definedRange.endDate as Date)
                        );
                    },
                }
            ]}
        />
    );
}
