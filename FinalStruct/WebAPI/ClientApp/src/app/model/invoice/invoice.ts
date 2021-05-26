import { Position } from '../position/position';
import { ThirdPartyPerson } from '../thirdPartyPerson/third-party-person';

export class Invoice {
    id: number;
    number: string;
    date: Date;
    thirdPartyPerson: ThirdPartyPerson;
    positions: Position[];
    vat: number;
}
