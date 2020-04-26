import { Pipe, PipeTransform, NgModule } from "@angular/core";

@Pipe({ name: "status" })
export class EnumDescriber implements PipeTransform {
  transform(value: any, source: any): string {
    return source[value] || value;
  }
}

export function Describe(value: any, source: any): string {
  return source[value] || value;
}

export const BooleanDesc = {
  false: "Não",
  true: "Sim",
};

// Fernando - How to use this helper: You will have a Enum Class like this:
// export enum ETaskStatus {
//  All = 0,
//  Todo = 1,
//  Done = 2,
//}

//export const ETaskStatusDesc = {
//  [ETaskStatus.All]: "Todos",
//  [ETaskStatus.Todo]: "Pendentes",
//  [ETaskStatus.Done]: "Executados",
//};

// Then, from a Class, you will cause it like this:
// Describe(d.Status, ETaskStatusDesc) (where status is the number field containing the ETaskStatus, and I'll pass the Translator ETaskStatusDesc)
// Note: I left on "Equipment-backgroundtask.component.ts" on method "load()" a sample that will print on console the Descriptor. Just uncomment it:

//sample of use the Descriptor of Enums. See documentation on enum-describer.service.ts - describe to make it works
//let equipmentBackGroundTaskLog = list as GetBackGroundTaskResult[];
//console.log(
//  "List of Equipment BackGroundTaskResult before Describe (with int on Status):",
//  equipmentBackGroundTaskLog
//);
//equipmentBackGroundTaskLog.forEach((item) => {
//  console.log(Describe(item.Status, ETaskStatusDesc));
//});
//sample of use the Descriptor of Enums. See documentation on enum-describer.service.ts - describe to make it works
