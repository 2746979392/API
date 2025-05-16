using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace XINJE
{
	public struct IO_Set{
		public ushort NodeId;
		public ushort SlotId;
		public uint Port;
		public uint Value;
	};

public static class XINJEMC
	{
		const String XINJEDLL_PATH = "XINJEMC_X64.dll";
		//控制器功能
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_connect_open(ushort connectNo, ushort type, string pconnectstring, uint dwBaudRate);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_connect_close(ushort connectNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_controller_restart(ushort connectNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_connect_status(ushort connectNo, ushort[] status);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_controller_soft_version(ushort connectNo, uint[] upperVerID, uint[] lowerVerID);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_controller_ip_address(ushort connectNo, string portName, byte[] ipAddr);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_controller_ip_address(ushort connectNo, string portName, byte[] ipAddr);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_firmware_version(ushort connectNo, byte[] firmwareVersion);

		//轴操作功能
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_status(ushort connectNo, ushort axisId, ushort[] axisStatus);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_err(ushort connectNo, ushort axisId, uint[] err);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_ctrl_mode(ushort connectNo, ushort axisId, ushort[] ctrlMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_target_position(ushort connectNo, ushort axisId, double[] position);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_target_velocity(ushort connectNo, ushort axisId, double[] velocity);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_target_accelerate(ushort connectNo, ushort axisId, double[] accelerate);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_target_torque(ushort connectNo, ushort axisId, double[] torque);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_actual_position(ushort connectNo, ushort axisId, double[] position);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_actual_velocity(ushort connectNo, ushort axisId, double[] velocity);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_actual_accelerate(ushort connectNo, ushort axisId, double[] accelerate);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_actual_torque(ushort connectNo, ushort axisId, double[] torque);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_command_position(ushort connectNo, ushort axisId, double[] position);

		//修改齿轮绑定比例
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_gearin_ratio(ushort connectNo, ushort slaveId, double numerator, double denominator);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_gearin_ratio(ushort connectNo, ushort slaveId, double[] numerator, double[] denominator);

		//探针功能
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_touch_probe_mode(ushort connectNo, ushort axisId, ushort channel, ushort enable, ushort edge, ushort trigMode, ushort source, ushort signal, string signalName, ushort signalNum);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_touch_probe_mode(ushort connectNo, ushort axisId, ushort channel, ushort[] enable, ushort[] edge, ushort[] trigMode, ushort[] source, ushort[] signal, byte[] signalName, ushort[] signalNum);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_touch_probe_value(ushort connectNo, ushort axisId, ushort channel, double[] probeValue);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_touch_probe_count(ushort connectNo, ushort axisId, ushort channel, ushort[] num);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_reset_touch_probe(ushort connectNo, ushort axisId, ushort channel);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_touch_probe_window(ushort connectNo, ushort axisId, ushort channel, ushort windowUsed, double windowStart, double windowEnd);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_touch_probe_window(ushort connectNo, ushort axisId, ushort channel, ushort[] windowUsed, double[] windowStart, double[] windowEnd);

		//高速计数功能
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_counter_count_switch(ushort connectNo, ushort countId, ushort enable);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_counter_count_status(ushort connectNo, ushort countId, ushort[] status);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_counter_mode(ushort connectNo, ushort countId, ushort countMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_counter_mode(ushort connectNo, ushort countId, ushort[] countMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_counter_count(ushort connectNo, ushort countId, int count);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_counter_count(ushort connectNo, ushort countId, int[] count);

		//寄存器功能
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort pmc_get_register(ushort connectNo, string registerName, ushort serialNum, ushort count, byte[] value);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort pmc_set_register(ushort connectNo, string registerName, ushort serialNum, ushort count, byte[] value);

		//读写IO功能
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_io_in_bit_sequence(ushort connectNo, ushort bitNo, byte[] value);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_io_out_bit_sequence(ushort connectNo, ushort bitNo, byte[] value);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_io_out_bit_sequence(ushort connectNo, ushort bitNo, byte value);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_io_in_port_sequence(ushort connectNo, ushort portNo, uint[] value);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_io_out_port_sequence(ushort connectNo, ushort portNo, uint[] value);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_io_out_port_sequence(ushort connectNo, ushort portNo, uint value);
		
		//ethercat
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_get_object_node(ushort connectNo, ushort axisId, ushort index, byte subIndex, byte[] valueLen, uint[] value);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_set_object_node(ushort connectNo, ushort axisId, ushort index, byte subIndex, byte valueLen, uint value);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_get_pdo_ctrl_mode(ushort connectNo, ushort axisId, ushort[] controlMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_get_pdo_position(ushort connectNo, ushort axisId, int[] position);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_get_pdo_velocity(ushort connectNo, ushort axisId, int[] velocity);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_get_pdo_torque(ushort connectNo, ushort axisId, int[] torque);

		//任务周期
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_cycle_time(ushort connectNo, double[] cycleTime);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_get_consume_time_fieldbus(ushort connectNo, ushort portNum, double[] averageTime, double[] maxTime, uint[] cycles);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_clear_consume_time_fieldbus(ushort connectNo, ushort portNum);

		//轴配置
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_config_axis_type(ushort connectNo, ushort axisId, ushort[] axisType);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_config_pulse_movement(ushort connectNo, ushort axisId, double pulse, double movement);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_config_pulse_movement(ushort connectNo, ushort axisId, double[] pulse, double[] movement);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_softlimit_unit(ushort connectNo, ushort axisId, ushort enable, double negativePos, double positivePos, double maxDec, double maxDecDis);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_softlimit_unit(ushort connectNo, ushort axisId, ushort[] enable, double[] negativePos, double[] positivePos, double[] maxDec, double[] maxDecDis);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_config_counting_type(ushort connectNo, ushort axisId, ushort countingType);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_config_counting_type(ushort connectNo, ushort axisId, ushort[] countingType);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_config_counting_limit(ushort connectNo, ushort axisId, double limitValue);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_config_counting_limit(ushort connectNo, ushort axisId, double[] limitValue);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort pmc_set_io_config(ushort connectNo, ushort mapIoType, string ioName, ushort ioIndex);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort pmc_get_io_config(ushort connectNo, ushort mapIoType, byte[] ioName, ushort[] ioIndex);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_axis_vel_param_max(ushort connectNo, ushort axisId, double maxVel, double maxAccDec, double maxJerk);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_vel_param_max(ushort connectNo, ushort axisId, double[] maxVel, double[] maxAccDec, double[] maxJerk);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_sto_status(ushort connectNo, ushort axisId, ushort[] STOstatus);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_iostatus(ushort connectNo, ushort axisId, uint[] IOStatus);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_axis_num(ushort connectNo, ushort[] axisNum);

		//修改运动指令参数
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_velocity_type(ushort connectNo, ushort axisId, ushort velType);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_velocity_type(ushort connectNo, ushort axisId, ushort[] velType);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_profile_velocity_time(ushort connectNo, ushort axisId, double vel, double accT, double decT, double smoothT);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_profile_velocity_time(ushort connectNo, ushort axisId, double[] vel, double[] accT, double[] decT, double[] smoothT);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_reset_target_position(ushort connectNo, ushort axisId, double pos);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_change_velocity(ushort connectNo, ushort axisId, double vel, double accT, double decT, double smoothT);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_change_torque(ushort connectNo, ushort axisId, double targetTrq);

		//单轴运动
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_axis_enable(ushort connectNo, ushort axisId);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_axis_disable(ushort connectNo, ushort axisId);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_reset_fault(ushort connectNo, ushort axisId);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_position_move(ushort connectNo, ushort axisId, double targetPos, short dir, ushort moveMode, ushort bufferMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_move_superpose(ushort connectNo, ushort axisId, double distance, double vel, double accT, double decT, double smoothT);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_velocity_move(ushort connectNo, ushort axisId, short dir, ushort bufferMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_continue_move(ushort connectNo, ushort axisId, double pos, double endVel, short dir, short endVelDir, ushort moveMode, ushort bufferMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_axis_stop(ushort connectNo, ushort axisId, ushort stopMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_gear_in(ushort connectNo, ushort masterId, ushort slaveId, ushort sourceType, double numerator, double denominator, ushort bufferMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_gear_out(ushort connectNo, ushort slaveId);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_home(ushort connectNo, ushort axisId, double offset, ushort bufferMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_control_mode(ushort connectNo, ushort axisId, ushort ctrlMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_torque_control(ushort connectNo, ushort axisId, double targetTrq, double ramp, double maxLimitVel, double range, ushort bufferMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_position(ushort connectNo, ushort axisId, double pos);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_axis_AMF(ushort connectNo, ushort axisId, ushort filterEnable, ushort filterNum, ushort filterMode);

		//多轴运动
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_group_inst_ptp(ushort connectNo, ushort groupId, double[] targetPosList, ushort coordSys, ushort positionMode, ushort bufferMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_group_inst_line(ushort connectNo, ushort groupId, double[] targetPosList, ushort coordSys, ushort positionMode, ushort bufferMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_group_inst_circle(ushort connectNo, ushort groupId, double[] auxPoint, double[] endPoint, ushort circleMode, ushort pathMode, ushort coordSys, ushort positionMode, ushort bufferMode);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_set_vector_profile(ushort connectNo, ushort groupId, double velocity, double acc, double dec, double jerk, double velFactor, double accFactor, double jerkFactor);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_vector_profile(ushort connectNo, ushort groupId, double[] velocity, double[] acc, double[] dec, double[] jerk, double[] velFactor, double[] accFactor, double[] jerkFactor);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_group_inst_stop(ushort connectNo, ushort groupId, double dec, double jerk, double decFactor, double jerkFactor);

		//ethercat激活和获取从站个数
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_master_active(ushort connectNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_master_get_slave_num(ushort connectNo, ushort portNum, ushort[] slaveNum);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_master_get_active_status(ushort connectNo, ushort portNum, ushort[] state);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_master_get_slave_connect_info(ushort connectNo, ushort portNum, ushort[] state, ushort[] firstErrSlave);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_get_ethercat_frame_count(ushort connectNo, ushort portNum, uint[] sendFrameCnt, uint[] lostFrameCnt, uint[] txErrorFrameCnt, uint[] rxErrorFrameCnt);

		//multiaxes_move
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_multiaxes_line_move(ushort connectNo, ushort crdId, ushort axisNum, ushort[] axisList, double[] targetPos, double startVel, double vel, double endVel, double acc, double dec, ushort posMode, ushort velType, double jerk);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_multiaxes_circle_radius_move(ushort connectNo, ushort crdId, ushort[] axisList, double[] targetPos, double radius, ushort circleDir, double startVel, double vel, double endVel, double acc, double dec, ushort posMode, ushort velType, double jerk);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_multiaxes_helix_move(ushort connectNo, ushort crdId, ushort[] axisList, double[] centerPos, double[] targetPos, ushort circleNum, ushort circleDir, double startVel, double vel, double endVel, double acc, double dec, ushort posMode, ushort velType, double jerk);

		//坐标系建立
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_set_config(ushort connectNo, ushort crdId, ushort axisCnt, ushort[] axisList, ushort setOriginFlag, double[] originPos);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_get_config(ushort connectNo, ushort crdId, ushort[] axisCnt, ushort[] axisList, ushort[] setOriginFlag, double[] originPos);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_set_vel_acc_limit(ushort connectNo, ushort crdId, double synVelMax, double synAccMax);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_get_vel_acc_limit(ushort connectNo, ushort crdId, double[] synVelMax, double[] synAccMax);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_get_status(ushort connectNo, ushort crdId, ushort[] status);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_get_err(ushort connectNo, ushort crdId, ushort[] crdErr, ushort[] lineNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_get_pos(ushort connectNo, ushort crdId, double[] pos);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_get_vel(ushort connectNo, ushort crdId, double[] vel);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_clear(ushort connectNo, ushort crdId, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_set_override(ushort connectNo, ushort crdId, double velRatio, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_open_lookahead(ushort connectNo, ushort crdId, ushort mode, double accMax, double radius);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_set_pause_IO_output(ushort connectNo, ushort crdId, ushort activeMode, ushort IOControlNum, IO_Set[] IOArray);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_get_pause_IO_output(ushort connectNo, ushort crdId, ushort[] activeMode, ushort[] IOControlNum, IO_Set[] IOArray);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_get_remain_buffer_size(ushort connectNo, ushort crdId, uint[] remainSize, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_get_buffer_segNum(ushort connectNo, ushort crdId, uint[] segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_set_velocity_type(ushort connectNo, ushort crdId, ushort velType, double jerk);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_crd_get_velocity_type(ushort connectNo, ushort crdId, ushort[] velType, double[] jerk);

		//conti_move
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_move_start(ushort connectNo, ushort crdId, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_move_pause(ushort connectNo, ushort crdId, ushort mode, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_move_stop(ushort connectNo, ushort crdId, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_line_G00(ushort connectNo, ushort crdId, ushort axisNum, ushort[] axisList, double[] tragetPos, double vel, double acc, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_line(ushort connectNo, ushort crdId, ushort axisNum, ushort[] axisList, double[] tragetPos, double vel, double acc, double endVel, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_circle_radius(ushort connectNo, ushort crdId, ushort axisNum, ushort[] axisList, double[] tragetPos, double radius, double vel, double acc, double endVel, ushort circleDir, ushort circleNum, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_line_XY(ushort connectNo, ushort crdId, double posX, double posY, double vel, double acc, double endVel, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_line_XYZ(ushort connectNo, ushort crdId, double posX, double posY, double posZ, double vel, double acc, double endVel, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_line_XYZA(ushort connectNo, ushort crdId, double posX, double posY, double posZ, double posA, double vel, double acc, double endVel, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_line_XYZAB(ushort connectNo, ushort crdId, double posX, double posY, double posZ, double posA, double posB, double vel, double acc, double endVel, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_circle_XYR(ushort connectNo, ushort crdId, double posX, double posY, double radius, double vel, double acc, double endVel, double Depth, ushort circleDir, ushort circleNum, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_circle_XYC(ushort connectNo, ushort crdId, double posX, double posY, double centerX, double centerY, double vel, double acc, double endVel, double depth, ushort circleDir, ushort circleNum, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_circle_YZR(ushort connectNo, ushort crdId, double posY, double posZ, double radius, double vel, double acc, double endVel, double depth, ushort circleDir, ushort circleNum, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_circle_YZC(ushort connectNo, ushort crdId, double posY, double posZ, double centerY, double centerZ, double vel, double acc, double endVel, double depth, ushort circleDir, ushort circleNum, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_circle_XZR(ushort connectNo, ushort crdId, double posX, double posZ, double radius, double vel, double acc, double endVel, double depth, ushort circleDir, ushort circleNum, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_circle_XZC(ushort connectNo, ushort crdId, double posX, double posZ, double centerX, double centerZ, double vel, double acc, double endVel, double depth, ushort circleDir, ushort circleNum, ushort posMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_time_delay(ushort connectNo, ushort crdId, double delayTime, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_wait_IO_input(ushort connectNo, ushort crdId, ushort nodeId, ushort slotId, ushort port, ushort value, ushort timeOutMode, double delayTime, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_set_IO_output(ushort connectNo, ushort crdId, ushort IOControlNum, IO_Set[] IOArray, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_set_delay_IO_output(ushort connectNo, ushort crdId, ushort IOControlNum, IO_Set[] IOArray, ushort outbitMode, ushort delayMode, double delayValue, double reserveTime, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_axis_move(ushort connectNo, ushort crdId, ushort axisId, double pos, double vel, double acc, double jerk, ushort moveMode, ushort blockMode, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_gear_move(ushort connectNo, ushort crdId, ushort axisId, double pos, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_set_G00_blending(ushort connectNo, ushort crdId, ushort enable, ushort blendMode, double blendParameter, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_wait_IO_input_sequence(ushort connectNo, ushort crdId, ushort bitNo, ushort timeOutMode, double delayTime, ushort value, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_set_IO_output_sequence(ushort connectNo, ushort crdId, ushort bitNo, ushort value, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_set_delay_IO_output_sequence(ushort connectNo, ushort crdId, ushort bitNo, ushort value, ushort outbitMode, ushort delayMode, double delayValue, double reverseTime, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_pause_input(ushort connectNo, ushort crdId, uint segNum, ushort bufferNo);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_conti_clear_IO_action(ushort connectNo, ushort crdId, ushort nodeId, ushort slotId, uint value, ushort bufferNo);

		//SDO读写
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_write_sdo_data(ushort connectNo, ushort nodeId, ushort objectIndex, byte objectSubIndex, byte dataSize, uint value);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_read_sdo_data(ushort connectNo, ushort nodeId, ushort objectIndex, byte objectSubIndex, byte[] dataSize, uint[] value);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_quickwrite_sdo_data(ushort connectNo, ushort nodeId, ushort objectIndex, byte objectSubIndex, byte dataSize, uint value);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_quickread_sdo_data(ushort connectNo, ushort nodeId, ushort objectIndex, byte objectSubIndex);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_read_sdo_response(ushort connectNo, ushort nodeId, ushort[] pDone, byte[] dataSize, uint[] value);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_wait_sdo_alldone(ushort connectNo, ushort nodeNum, ushort[] nodeId);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort emc_check_sdo_alldone(ushort connectNo, ushort nodeId, ushort[] pState);

		//密码功能
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_login_password(ushort connectNo, string loginPassword);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_check_password(ushort connectNo, string currentPassword);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_write_password(ushort connectNo, string newPassword);
		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_get_sysid(ushort connectNo, uint[] systemId);

		[DllImport(XINJEDLL_PATH, CallingConvention = CallingConvention.StdCall)]
		public static extern ushort mc_dll_log_switch(ushort logSwitch);

	}
}
