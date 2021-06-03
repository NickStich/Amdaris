import { Position } from '../position/position';
import { ThirdPartyPerson } from '../thirdPartyPerson/third-party-person';

export class Invoice {
    id: number;
    number: string;
    date: Date;
    thirdPartyPersonId: number;
    positions: Position[];
    type: number;
    vat: number;
}
